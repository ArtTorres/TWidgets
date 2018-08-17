using System;
using System.Collections.Generic;
using System.Text;

namespace QApp
{
    public abstract class QApplication
    {
        protected ConsoleColor DefaultColor = ConsoleColor.Gray;

        protected bool _prevProgressMessage = false;
        protected ConsoleColor _initialColor;

        public bool DisplayArguments { get; set; }
        public bool DisplayEnvironment { get; set; }

        [OptionSet(-1)]
        public ApplicationOptions AppOptions { get; set; }

        public QApplication()
        {
            _initialColor = Console.ForegroundColor;

            this.DisplayEnvironment = true;
            this.DisplayArguments = true;
        }

        public void ShowHeader()
        {
            foreach (var line in Header.Instance.Draw(Console.BufferWidth, AssemblyDescription.Description))
            {
                Console.WriteLine(line);
            }
        }

        public void ShowHelp()
        {
            //PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            //for (int i = 0; i < properties.Length; i++)
            //{
            //    PropertyInfo propertyInfo = properties[i];
            //    OptionSetAttribute attribute = GetAttribute<OptionSetAttribute>(propertyInfo);

            //    if (null != attribute)
            //    {
            //        QOption option = (QOption)propertyInfo.GetValue(this);
            //        //this.Print(MessageType.Progress, option.Help);
            //    }
            //}

            foreach (var option in OptionUtil.GetOptions(this).OrderBy(s => s.Order))
            {
                foreach (var line in HelpTemplate.Build(AssemblyDescription.AssemblyFile, option.Help))
                {
                    this.Print(MessageType.Help, MessagePriority.High, line);
                }
            }

            //foreach (var line in HelpTemplate.Display(
            //    OptionUtil.GetOptions(this).SelectMany(s => s.Help)
            //))
            //{
            //    this.Print(MessageType.Text, MessagePriority.High, line);
            //}

            //foreach (var option in OptionUtil.GetOptions(this))
            //{
            //    foreach (var help in option.Help)
            //    {
            //        this.Print(MessageType.Text, MessagePriority.High, help.Description);
            //    }
            //}
        }

        public bool ShowExceptions()
        {
            //foreach (var ex in errors)
            //{
            //    this.Print(MessageType.Error, MessagePriority.High, ex.Message);
            //}

            //PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            //for (int i = 0; i < properties.Length; i++)
            //{
            //    PropertyInfo propertyInfo = properties[i];
            //    OptionSetAttribute attribute = OptionUtil.GetAttribute<OptionSetAttribute>(propertyInfo);

            //    if (null != attribute)
            //    {
            //        QOption option = (QOption)propertyInfo.GetValue(this);

            //        foreach (var ex in option.Exceptions)
            //        {
            //            this.Print(MessageType.Error, MessagePriority.High, ex.Message);

            //            if (!found) found = true;
            //        }
            //    }
            //}

            bool found = false;
            foreach (var option in OptionUtil.GetOptions(this))
            {
                foreach (var ex in option.Exceptions)
                {
                    this.Print(MessageType.Error, MessagePriority.High, ex.Message);

                    if (!found) found = true;
                }
            }

            return found;
        }

        public void ShowEnvironment()
        {
            this.Print(MessageType.Warning, MessagePriority.High, "Environment Version: {0}", Environment.Version.ToString());
        }

        public void ShowArguments(string[] args)
        {
            this.Print(MessageType.Arguments, MessagePriority.High, string.Join(" ", args));
        }

        public abstract void ExecutionProcess();

        public void Execute(string[] args)
        {
            this.ShowHeader();

            try
            {
                OptionUtil.SetOptions(this, args);

                if (this.DisplayArguments)
                    this.ShowArguments(args);

                if (this.AppOptions.ShowHelp)
                {
                    this.ShowHelp();
                }
                else if (!this.ShowExceptions())
                {
                    if (this.DisplayEnvironment)
                        this.ShowEnvironment();

                    Console.ForegroundColor = _initialColor;

                    this.ExecutionProcess();
                }
            }
            catch (Exception ex)
            {
                this.Print(MessageType.Error, MessagePriority.High, ex.Message);
            }
            finally
            {
                Console.ForegroundColor = _initialColor;
            }
        }

        //private void SetOptions(string[] args)
        //{
        //    PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        //    for (int i = 0; i < properties.Length; i++)
        //    {
        //        PropertyInfo propertyInfo = properties[i];
        //        OptionSetAttribute attribute = OptionUtil.GetAttribute<OptionSetAttribute>(propertyInfo);

        //        if (null != attribute)
        //        {
        //            var obj = typeof(OptionUtil)
        //            .GetMethod("CreateOptionSet", new[] { typeof(string[]), typeof(char) })
        //            .MakeGenericMethod(propertyInfo.PropertyType)
        //            .Invoke(this, new object[] { args, '-' });

        //            propertyInfo.SetValue(
        //                this,
        //                obj,
        //                null
        //            );
        //        }
        //    }
        //}

        //private T GetAttribute<T>(MemberInfo member) where T : Attribute
        //{
        //    object[] customAttributes = member.GetCustomAttributes(true);
        //    T result;
        //    for (int i = 0; i < customAttributes.Length; i++)
        //    {
        //        object obj = customAttributes[i];
        //        if (obj is T)
        //        {
        //            result = (T)((object)obj);
        //            return result;
        //        }
        //    }
        //    result = default(T);
        //    return result;
        //}

        #region Print

        protected void Print(string message, params object[] arg)
        {
            Console.WriteLine(message, arg);
        }

        protected void Print(MessageType type, MessagePriority priority, string message, params object[] arg)
        {
            this.Print(new QMessage
            {
                MessageType = type,
                Text = string.Format(message, arg),
                Priority = priority
            });
        }

        protected void Print(QMessage message)
        {
            // skip message if lower priority
            if (this.AppOptions.MessagePriority < message.Priority) return;

            this.SetConsoleColor(message.MessageType);

            if (this._prevProgressMessage && message.MessageType != MessageType.Progress)
            {
                Console.Write("\n");
            }

            switch (message.MessageType)
            {
                case MessageType.Data:
                case MessageType.Resume:
                case MessageType.Highlight:
                case MessageType.Text:
                case MessageType.Help:
                    Console.WriteLine("{0}", message.Text);
                    this._prevProgressMessage = false;
                    break;
                case MessageType.Progress:
                    Console.Write("\r{0}", message.Text);
                    this._prevProgressMessage = true;
                    break;
                case MessageType.Arguments:
                    Console.WriteLine("[ARGS] {0}", message.Text);
                    this._prevProgressMessage = false;
                    break;
                default:
                    Console.WriteLine("[{0}] {1}", message.MessageType.ToString().ToUpper(), message.Text);
                    this._prevProgressMessage = false;
                    break;
            }
        }

        protected void SetConsoleColor(MessageType type)
        {
            switch (type)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return;
                case MessageType.Data:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return;
                case MessageType.Resume:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return;
                case MessageType.Help:
                case MessageType.Progress:
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                case MessageType.Arguments:
                case MessageType.Highlight:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    return;
            }
            Console.ForegroundColor = this.DefaultColor;
        }

        #endregion

        #region Events

        protected void MonitorTask(QTask task)
        {
            task.Started += this.OnTaskStarted;
            task.Completed += this.OnTaskCompleted;
            task.Failed += this.OnTaskFailed;
            task.Progress += this.OnTaskProgress;
        }
        protected void ForgetTask(QTask task)
        {
            task.Started -= this.OnTaskStarted;
            task.Completed -= this.OnTaskCompleted;
            task.Failed -= this.OnTaskFailed;
            task.Progress -= this.OnTaskProgress;
        }

        protected void OnTaskProgress(object sender, MessageEventArgs e)
        {
            this.Print(e.Message);
        }

        protected void OnTaskFailed(object sender, MessageEventArgs e)
        {
            this.Print(e.Message);
        }

        protected void OnTaskCompleted(object sender, MessageEventArgs e)
        {
            this.Print(e.Message);
        }

        protected void OnTaskStarted(object sender, MessageEventArgs e)
        {
            this.Print(e.Message);
        }

        #endregion
    }
}
