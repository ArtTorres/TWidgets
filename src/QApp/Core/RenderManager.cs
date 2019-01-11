using System;
using System.Collections.Generic;
using System.Text;

namespace QApp.Core
{
    public class RenderManager
    {
        private static RenderManager _instance;

        public static RenderManager Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new RenderManager();

                return _instance;
            }
        }

        private RenderManager()
        {

        }
    }
}
