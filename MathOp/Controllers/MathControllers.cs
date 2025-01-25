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
        // Método Post que se encarga de las opraciones
        [HttpPost("calculate")]
        public IActionResult CalculatePost([FromBody] MathRequest request)
        {
            float res = request.Num1;

            res = Operation(res, request.Op1, request.Num2);

            res = Operation(res, request.Op2, request.Num3);

            return Ok(new { Res = res });
        }

        // Método Get que se encarga de las opraciones
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

