### Razor Syntax

Razor supports C# and uses the `@` symbol to transition from HTML to C#. Razor evaluates C# expressions and renders them in the HTML output.


## Implicit Razor Expressions

Implicit Razor expressions start with `@` followed by C# code:

```cshtml
<p>@DateTime.Now</p>
<p>@DateTime.IsLeapYear(2016)</p>
```

## Explicit Razor Expression

Explicit Razor expressions consist of an `@` symbol with balanced parenthesis. To render last week's time, the following Razor markup is used:

    ```cshtml
    <p>Last week this time: @(DateTime.Now - TimeSpan.FromDays(7))</p>
    ```

    Any content within the @() parenthesis is evaluated and rendered to the output.

Implicit expressions, described in the previous section, generally can't contain spaces. In the following code, one week isn't subtracted from the current time:

    ```cshtml
    <p>Last week: @DateTime.Now - TimeSpan.FromDays(7)</p>
    ```

    The code renders the following HTML:

    ```html
    <p>Last week: 7/7/2016 4:39:52 PM - TimeSpan.FromDays(7)</p>
    ```

Explicit expressions can be used to concatenate text with an expression result:

    ```cshtml
    @{
        var joe = new Person("Joe", 33);
    }

    <p>Age@(joe.Age)</p>
    ```

`HtmlHelper.Raw` output isn't encoded but rendered as HTML markup.

    ```cshtml
    @Html.Raw("<span>Hello World</span>")
    ```

## Razor code blocks

Razor code blocks start with `@` and are enclosed by `{}`. Unlike expressions, C# code inside code blocks isn't rendered. Code blocks and expressions in a view share the same scope and are defined in order:

    ```cshtml
    @{
        var quote = "The future depends on what you do today. - Mahatma Gandhi";
    }

    <p>@quote</p>

    @{
        quote = "Hate cannot drive out hate, only love can do that. - Martin Luther King, Jr.";
    }

    <p>@quote</p>
    ```

    The code renders the following HTML:
    
    ```html
    <p>The future depends on what you do today. - Mahatma Gandhi</p>
    <p>Hate cannot drive out hate, only love can do that. - Martin Luther King, Jr.</p>
    ```

In code blocks, declare local functions with markup to serve as templating methods:

    ```cshtml
    @{
        void RenderName(string name)
        {
            <p>Name: <strong>@name</strong></p>
        }

        RenderName("Mahatma Gandhi");
        RenderName("Martin Luther King, Jr.");
    }
    ```

# [Bootswatch](https://bootswatch.com/default/)
