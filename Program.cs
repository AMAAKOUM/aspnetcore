namespace FirstCoreWebApplication
{
    public class Program
    {
        // le point d'entree dans le programme ou l application
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
           
            var app = builder.Build();

            // premier composant Middleware avec la methode Use
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("MiddleWare 1: Incoming Request\n ");
                await next();
                await context.Response.WriteAsync("Middleware 1: OutComing Request\n");
            });

            // second composant Middleware tjrs avec Use method
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 2: Incoming\n");
                await next();
                await context.Response.WriteAsync("Middleware 2: Outcoming\n");
            });
            // Troisieme composant middleware avec la methode Run
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Middleware 3: Incoming request and response generated\n");
            });
            app.Run();
        }
        
    }
}
