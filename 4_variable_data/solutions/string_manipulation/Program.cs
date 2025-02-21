/*
Set the quantity variable to the value obtained by extracting the text between the <span> and </span> tags.
Set the output variable to the value of input, then remove the <div> and </div> tags.
Replace the HTML character ™ (&trade;) with ® (&reg;) in the output variable.

Should print:
Quantity: 5000
Output: <h2>Widgets &reg;</h2><span>5000</span>
*/

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// Your work here
const string openSpan = "<span>";
const string closeSpan = "</span>";

int openSpanPosition = input.IndexOf(openSpan);
int closeSpanPosition = input.IndexOf(closeSpan);
openSpanPosition += openSpan.Length;

int quantityLength = closeSpanPosition - openSpanPosition;
quantity = input.Substring(openSpanPosition, quantityLength);

const string tradeSymbol = "&trade;";
const string regSymbol = "&reg;";
const string openDiv = "<div>";
const string closeDiv = "</div>";

output = input.Replace(openDiv, "");
output = output.Replace(closeDiv, "");
output = output.Replace(tradeSymbol, regSymbol);

Console.WriteLine($"Quantity: {quantity}");
Console.WriteLine($"Output: {output}");