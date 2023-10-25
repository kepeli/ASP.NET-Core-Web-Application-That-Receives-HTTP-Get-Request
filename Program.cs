var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        int firstNumber = 0, secondNumber = 0;
        string? operation = null;
        long? result = null;

        //FOR THE FIRST NUMBER
        if (context.Request.Query.ContainsKey("firstnumber"))
        {
            string firstNumberString = context.Request.Query["firstNumber"][0];
            if (!string.IsNullOrEmpty(firstNumberString))
            {
                firstNumber = Convert.ToInt32(firstNumberString);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid Input for 'firstNumber'\n");
            }
        }
        else 
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'firstNumber'\n");
        }

        //FOR THE SECOND NUMBER
        if (context.Request.Query.ContainsKey("secondNumber"))
        {
            string secondNumberString = context.Request.Query["secondNumber"][0];
            if (!string.IsNullOrEmpty (secondNumberString)) 
            {
                secondNumber = Convert.ToInt32(secondNumberString);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'secondNumber'\n");
        }

        //FOR THE OPERATION
        if (context.Request.Query.ContainsKey("operation"))
        {
            operation = Convert.ToString(context.Request.Query["operations"][0]);

            //FOR THE OPERATION CLACULATION
            if (operation == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operation == "-")
            {
                result = firstNumber - secondNumber;

            }
            else if (operation == "*")
            {
                result = secondNumber * firstNumber;
            }
            else if (operation == "/")
            {
                result = firstNumber / secondNumber;
            }
            else if (operation == "%")
            {
                result = firstNumber % secondNumber;
            }
            else
                if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid Operator");
        }
        else 
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid Operation");

        }
    }
});

app.Run();
