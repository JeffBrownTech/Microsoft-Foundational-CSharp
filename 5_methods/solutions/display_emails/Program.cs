string[,] corporate = 
{
    {"Robert", "Bavin"}, {"Simon", "Bright"},
    {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
    {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
};

string[,] external = 
{
    {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
    {"Shay", "Lawrence"}, {"Daren", "Valdes"}
};

string externalDomain = "hayworth.com";

for (int i = 0; i < corporate.GetLength(0); i++) 
{
    // display internal email addresses
    string firstName = corporate[i, 0];
    string lastName = corporate[i, 1];
    DisplayEmail(firstName, lastName);
}

for (int i = 0; i < external.GetLength(0); i++) 
{
    // display external email addresses
    string firstName = external[i, 0];
    string lastName = external[i, 1];
    DisplayEmail(firstName, lastName, externalDomain);
}

void DisplayEmail(string first, string last, string domain="contoso.com")
{
    string emailAddress = (first.Substring(0, 2) + last + "@" + domain).ToLower();
    Console.WriteLine(emailAddress);
}