using CookBook.Services.Helpers;
using System.Security.Claims;

namespace CookBook.API.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public JwtMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last();
            if(token != null)
            {
                //TO DO jeśli token jest niepoprawny (np 456), to wywala 500
                var jwtToken = AuthHelper.ValidateToken(token, _config);
                var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "role").Value;
                var claims = new[]
                {
                    new Claim(ClaimTypes.Role, role),
                };
                var identity = new ClaimsIdentity(claims, "basic");
                context.User = new ClaimsPrincipal(identity);
            }
            await _next(context);
        }
    }
}
