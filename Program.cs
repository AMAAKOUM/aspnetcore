using SecondCoreWebApplication.Models;

namespace SecondCoreWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // inscrire le service dans le conteneur DI 

            // ajout de services Framework Mvc 
            builder.Services.AddMvc();

            // Inscrire un DI Singleton par defaut
            builder.Services.Add(new ServiceDescriptor(typeof(IStudenRepository), new StudentRepository()));
            
            // pour inscrire DI Singleton
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudenRepository), typeof(StudentRepository), ServiceLifetime.Singleton));
            
            // pour inscrire un DI Transient (ephémère)
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudenRepository), typeof(StudentRepository), ServiceLifetime.Transient));
            
            // pour inscrire un DI Scoped (portée)
            //builder.Services.Add(new ServiceDescriptor(typeof(IStudenRepository), typeof(StudentRepository), ServiceLifetime.Scoped));
            

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            app.UseRouting();
            app.MapControllerRoute(
                name : "default",
                pattern : "{controller=Home}/{action=Index}/{id?}"
                );
            
            app.Run();
        }
    }
}
