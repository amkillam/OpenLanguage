# Complete Integration Example

This document demonstrates a comprehensive real-world example that integrates multiple OpenLanguage components to create a complete document processing application.

## Scenario: Mail Merge Report Generator

This example creates a sophisticated mail merge system that combines formula parsing, field instruction processing, and localization features to generate personalized financial reports.

> **Note**: This example demonstrates how to build a document template by generating field instruction strings. It does not perform evaluation or data merging, as the evaluation engine is not yet implemented.

### Data Models

```csharp
public class CustomerData
{
    public string Name { get; set; } = "";
    public string Company { get; set; } = "";
    public Address Address { get; set; } = new Address();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    public decimal CreditLimit { get; set; }
    public DateTime LastPaymentDate { get; set; }

    public decimal TotalBalance => Transactions.Sum(t => t.Amount);
    public decimal AverageTransaction => Transactions.Any() ? Transactions.Average(t => t.Amount) : 0;
    public int TransactionCount => Transactions.Count;
}

public class Address
{
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string ZipCode { get; set; } = "00000";
    public OpenLanguage.WordprocessingML.LanguageIdentifier Country { get; set; } = OpenLanguage.WordprocessingML.LanguageIdentifier.EnglishUS;
}

public class Transaction
{
    public DateTime Date { get; set; }
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
}
```

### Document Template Builder

This class constructs a document template using strongly-typed AST nodes from `OpenLanguage`.

```csharp
using OpenLanguage.WordprocessingML.FieldInstruction;
using OpenLanguage.WordprocessingML.FieldInstruction.Ast;
using OpenLanguage.WordprocessingML.Ast;
using OpenLanguage.WordprocessingML;
using System.Collections.Generic;
using System.Linq;

public class DocumentTemplate
{
    private readonly LanguageIdentifier _language;
    public List<ExpressionNode> Fields { get; }

    public DocumentTemplate(LanguageIdentifier language)
    {
        _language = language;
        Fields = new List<ExpressionNode>();
    }

    public void BuildTemplate()
    {
        AddHeaderFields();
        AddAddressSection();
        AddFinancialSummary();
        AddTransactionTable();
        AddFooterSection();
    }

    private void AddHeaderFields()
    {
        Fields.Add(FieldInstructionParser.Parse("DOCPROPERTY Company"));
        Fields.Add(CreateLocalizedDateField());
        Fields.Add(FieldInstructionParser.Parse("PAGE"));
        Fields.Add(FieldInstructionParser.Parse("NUMPAGES"));
    }

    private void AddAddressSection()
    {
        string greeting = GetLocalizedGreeting();
        string punctuation = GetLocalizedPunctuation();
        Fields.Add(FieldInstructionParser.Parse($@"GREETINGLINE \f ""{greeting}"" \l ""{punctuation}"""));
        Fields.Add(FieldInstructionParser.Parse($@"ADDRESSBLOCK \l {(int)_language}"));
        Fields.Add(CreateConditionalBarcodeField());
    }

    private void AddFinancialSummary()
    {
        string currencyFormat = GetLocalizedCurrencyFormat();
        Fields.Add(FieldInstructionParser.Parse($@"MERGEFIELD TotalBalance \# ""{currencyFormat}"""));
        Fields.Add(FieldInstructionParser.Parse($@"MERGEFIELD AverageTransaction \# ""{currencyFormat}"""));
        Fields.Add(FieldInstructionParser.Parse(@"= { MERGEFIELD TotalBalance } / { MERGEFIELD CreditLimit } * 100 \# ""0.00%"""));
        Fields.Add(FieldInstructionParser.Parse(@"= { DATE \@ d } - { MERGEFIELD LastPaymentDate \@ d }"));
    }

    private void AddTransactionTable()
    {
        Fields.Add(FieldInstructionParser.Parse(@"DATABASE \d ""transactions.mdb"" \c ""DSN=Access;DBQ=transactions.mdb;"" \s ""SELECT Date, Description, Amount FROM Transactions WHERE CustomerID = { MERGEFIELD CustomerID }"" \l 37"));
    }

    private void AddFooterSection()
    {
        string termsText = GetLocalizedTermsText();
        Fields.Add(FieldInstructionParser.Parse($@"HYPERLINK ""https://company.com/terms"" ""{termsText}"" \o ""View full terms and conditions"""));
        Fields.Add(FieldInstructionParser.Parse("DOCPROPERTY ContactInfo"));
    }

    private ExpressionNode CreateLocalizedDateField()
    {
        string dateFormat = _language switch
        {
            LanguageIdentifier.EnglishUS => "MMMM d, yyyy",
            LanguageIdentifier.EnglishUK => "d MMMM yyyy",
            LanguageIdentifier.FrenchFrance => "d MMMM yyyy",
            LanguageIdentifier.GermanGermany => "d. MMMM yyyy",
            LanguageIdentifier.Japanese => "yyyy年MM月dd日",
            _ => "MMMM d, yyyy"
        };
        return FieldInstructionParser.Parse($@"DATE \@ ""{dateFormat}""");
    }

    private ExpressionNode CreateConditionalBarcodeField()
    {
        return FieldInstructionParser.Parse(@"IF { MERGEFIELD Country } = ""UnitedStates"" { BARCODE { MERGEFIELD ZipCode } \f A } """"");
    }

    // Helper methods for localization
    private string GetLocalizedGreeting() => _language switch { LanguageIdentifier.FrenchFrance => "Cher", _ => "Dear" };
    private string GetLocalizedPunctuation() => _language switch { LanguageIdentifier.FrenchFrance => " :", _ => "," };
    private string GetLocalizedCurrencyFormat() => _language switch { LanguageIdentifier.EnglishUK => "£#,##0.00", LanguageIdentifier.FrenchFrance => "#,##0.00 €", _ => "$#,##0.00" };
    private string GetLocalizedTermsText() => _language switch { LanguageIdentifier.FrenchFrance => "Conditions Générales", _ => "Terms and Conditions" };
}
```

### Report Generation and Usage

```csharp
public class ReportGenerator
{
    public void Generate(DocumentTemplate template, CustomerData customer)
    {
        Console.WriteLine($"--- Generating Report for {customer.Name} ---");

        // In a real application, you would use these ASTs to build a document.
        // For this example, we just print the structure.

        Console.WriteLine("\nFIELD INSTRUCTIONS:");
        foreach (var field in template.Fields)
        {
            Console.WriteLine(field.ToString());
        }

        Console.WriteLine("--- End of Report ---");
    }
}

public class Program
{
    public static void Main()
    {
        var customer = new CustomerData
        {
            Name = "John Smith",
            Company = "Acme Corp",
            Address = new Address { Street = "123 Main St", City = "Anytown", State = "CA", ZipCode = "12345" },
            CreditLimit = 10000m,
            LastPaymentDate = DateTime.Now.AddDays(-15),
            Transactions = new List<Transaction> { new Transaction { Amount = 150.75m } }
        };

        // Generate report in English
        var usTemplate = new DocumentTemplate(LanguageIdentifier.EnglishUS);
        usTemplate.BuildTemplate();
        var generator = new ReportGenerator();
        generator.Generate(usTemplate, customer);

        // Generate report in French
        var frTemplate = new DocumentTemplate(LanguageIdentifier.FrenchFrance);
        frTemplate.BuildTemplate();
        generator.Generate(frTemplate, customer);
    }
}
```

This example demonstrates how `FieldInstructionParser` can be used to build a structured document template. The strongly-typed AST allows for easy construction and manipulation of complex fields, including nested fields and localized formats.
