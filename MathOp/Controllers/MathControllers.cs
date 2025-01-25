using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MathOp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathControllers : ControllerBase
    {
        [HttpPost("calculate")]
        public IActionResult CalculatePost([FromBody] MathRequest request)
        {
            float res = request.Num1;

            res = Operation(res, request.Op1, request.Num2);

            res = Operation(res, request.Op2, request.Num3);

            return Ok(new { Res = res });
        }
        // Método que maneja tanto la suma como la resta
        [HttpGet("calculate")]
        public IActionResult CalculateGet(float a, string op1, float b, string op2, float c)
        {
            float res = 0;

            res = Operation(a, op1, b); 

            res = Operation(res, op2, c); 

            return Ok(new { Res = res });
        }

        private float Operation(float a, string op, float b)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0)
                    {
                        throw new ArgumentException("Cannot divide by zero.");
                    }
                    return a / b;
                default:
                    throw new ArgumentException("Invalid operator. Use '+', '-', '*', or '/'.");
            }
        }
    }

    public class MathRequest
    {
        public float Num1 { get; set; }
        public required string Op1 { get; set; }
        public float Num2 { get; set; }
        public required string Op2 { get; set; }
        public float Num3 { get; set; }
    }

}

/*
using Microsoft.AspNetCore.Mvc;

namespace MathOp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathControllers : ControllerBase
    {
        // Método que maneja el cálculo usando POST
        [HttpPost("calculate")]
        public IActionResult CalculatePost([FromBody] MathRequest request)
        {
            float result = request.Num1;

            // Realizar la primera operación
            result = PerformOperation(result, request.Op1, request.Num2);

            // Realizar la segunda operación
            result = PerformOperation(result, request.Op2, request.Num3);

            return Ok(new { Result = result });
        }

        // Método que maneja el cálculo usando GET (ya implementado)
        [HttpGet("calculate")]
        public IActionResult CalculateGet(float num1, string op1, float num2, string op2, float num3)
        {
            float result = num1;

            // Realizar la primera operación
            result = PerformOperation(result, op1, num2);

            // Realizar la segunda operación
            result = PerformOperation(result, op2, num3);

            return Ok(new { Result = result });
        }

        // Método para realizar la operación matemática
        private float PerformOperation(float number1, string operation, float number2)
        {
            switch (operation)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    if (number2 == 0)
                    {
                        throw new ArgumentException("Cannot divide by zero.");
                    }
                    return number1 / number2;
                default:
                    throw new ArgumentException("Invalid operator. Use '+', '-', '*', or '/'.");
            }
        }
    }

    // Modelo para los datos que se reciben en POST
    public class MathRequest
    {
        public float Num1 { get; set; }
        public string Op1 { get; set; }
        public float Num2 { get; set; }
        public string Op2 { get; set; }
        public float Num3 { get; set; }
    }
}

*/