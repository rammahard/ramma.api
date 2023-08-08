# Simple Calculator

```csharp
SimpleCalculatorController simpleCalculatorController = client.SimpleCalculatorController;
```

## Class Name

`SimpleCalculatorController`


# Get Calculate

Calculates the expression using the specified operation.

```csharp
GetCalculateAsync(
    Models.GetCalculateInput input)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `operation` | [`OperationTypeEnum`](../../doc/models/operation-type-enum.md) | Template, Required | The operator to apply on the variables |
| `x` | `double` | Query, Required | The LHS value |
| `y` | `double` | Query, Required | The RHS value |

## Response Type

`Task<double>`

## Example Usage

```csharp
GetCalculateInput getCalculateInput = new GetCalculateInput
{
    Operation = OperationTypeEnum.MULTIPLY,
    X = 222.14,
    Y = 165.14,
};

try
{
    double? result = await simpleCalculatorController.GetCalculateAsync(getCalculateInput);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

