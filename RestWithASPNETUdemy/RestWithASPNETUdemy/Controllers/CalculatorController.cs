using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            double sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }


    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult GetSub(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            double sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult GetMult(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            double sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult GetDiv(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            double sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }

    // Media
    [HttpGet("med/{firstNumber}/{secondNumber}")]
    public IActionResult GetMed(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            double sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("raiz/{firstNumber}/{secondNumber}")]
    public IActionResult GetRaiz(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            double sum = Math.Sqrt(ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double
            .TryParse(strNumber, System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }

    private double ConvertToDecimal(string strNumber)
    {
        double value;
        if (double.TryParse(strNumber, out value))
        {
            return value;
        }
        return 0;

    }
}
