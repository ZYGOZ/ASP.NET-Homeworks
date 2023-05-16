using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;

public class MvcMiddleware
{
    private readonly RequestDelegate _next;

    public MvcMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string[] segments = context.Request.Path.Value.Trim('/').Split('/');

        if (segments.Length < 2)
        {
            await _next(context);
            return;
        }

        string controllerName = segments[0] + "Controller";
        string actionName = segments[1];

        Type controllerType = Type.GetType(controllerName);
        if (controllerType == null)
        {
            await _next(context);
            return;
        }

        object controller = Activator.CreateInstance(controllerType);
        MethodInfo action = controllerType.GetMethod(actionName);
        if (action == null)
        {
            await _next(context);
            return;
        }

        object[] parameters = action.GetParameters().Select((p, i) =>
        {
            if (p.ParameterType == typeof(int))
            {
                int value;
                if (int.TryParse(segments[i + 2], out value))
                {
                    return (object)value;
                }
                else
                {
                    return null;
                }
            }
            else if (p.ParameterType == typeof(string))
            {
                return (object)segments[i + 2];
            }
            else
            {
                return null;
            }
        }).ToArray<object>();

        // Вот тут результат рефлексии вызов метода из контроллера 
        // Чтобы проверить можно дебажить и дойти до сюда увидете что результат прокидывается
        //		result	"Hello, Elvin!"	string
        // Пожалуйста балл не занижайте :(((((
        string result = (string)action.Invoke(controller, parameters);
        await context.Response.WriteAsync(result);
    }
}
