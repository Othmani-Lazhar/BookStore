namespace BookStore.Data.DataAccess.Configuration
{
    using System;
    using System.Web;
    using BookStore.Logger;
    using NHibernate;

    public class NHibernateHttpModule : IHttpModule
    {
        private const string KEY = "_SESSINKEY_";
        private static ISession nsession;

        public static ISession CurrentSession
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    if (nsession != null)
                    {
                        return nsession;
                    }

                    nsession = SessionHelper.OpenSession();
                    return nsession;
                }

                HttpContext currentContext = HttpContext.Current;
                var session = currentContext.Items[KEY] as ISession;

                if (session == null)
                {
                    session = SessionHelper.OpenSession();
                    currentContext.Items[KEY] = session;
                }

                return session;
            }
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(this.Context_BeginRequest);
            context.EndRequest += new EventHandler(this.Context_EndRequest);
        }

        public void Context_EndRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            HttpContext context = application.Context;

            var session = context.Items[KEY] as ISession;
            if (session != null && session.IsOpen)
            {
                try
                {
                    //// session.Flush();
                    session.Close();
                }
                catch (HibernateException ex)
                {
                    LoggerService.Log.Error("Nhibernate", ex);
                }

                context.Items[KEY] = null;
            }
        }

        public void Context_BeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Items[KEY] = SessionHelper.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
