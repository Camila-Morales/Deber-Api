public class TimeMiddleware{
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest){
        next = nextRequest;
    }

    //Metodo para que nos devuelva la hora del servidor 
    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context){
        
        await next(context);

        if (context.Request.Query.Any(p=> p.Key == "time")){
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }

    }
}

//Clase para agregar el middleware dentro de la configuracion
    public static class TimeMiddlewareExtension{
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder){
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }