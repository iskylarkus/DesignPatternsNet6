namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class ProcessHandler : IProcessHandler
    {
        private IProcessHandler nextProcessHandler;

        public virtual object handle(object o)
        {
            if (nextProcessHandler != null)
            {
                return nextProcessHandler.handle(o);
            }

            return null;
        }

        public IProcessHandler SetNext(IProcessHandler processHandler)
        {
            nextProcessHandler = processHandler;
            return nextProcessHandler;
        }
    }
}
