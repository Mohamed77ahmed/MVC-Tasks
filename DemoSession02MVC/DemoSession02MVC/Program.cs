namespace DemoSession02MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Resgister Services In DI Container
            builder.Services.AddControllersWithViews();
            #endregion
            var app = builder.Build();


           
            //app.MapGet("/", () => "Hello World!");// Default segment
            //app.MapGet("/mo", () => "Hello mo!");// static segment

            //app.MapGet("/{name}", async(Context) =>
            //{
            //    var name = Context.GetRouteValue("name");
            //    await Context.Response.WriteAsync($"hello {name}");
            //});// dynamic segment

            //app.MapGet("/mr{name}", async (Context) =>
            //{
            //    var name = Context.GetRouteValue("name");
            //    await Context.Response.WriteAsync($"hello mr{name}");
            //});// mixed segment


            app.UseStaticFiles();

            app.MapControllerRoute(
               name: "default",
               pattern:"{Controller=Movies}/{Action=index}/{Id:int?}"
               );
            app.Run();
        }
    }
}
