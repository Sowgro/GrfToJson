// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using OMI.Formats.GameRule;
using OMI.Workers.GameRule;

string dir = args[0];
string[] files = Directory.GetFiles(dir, "*.grf", SearchOption.TopDirectoryOnly);

foreach(string filename in files) {
    GameRuleFileReader reader = new GameRuleFileReader(0);
    GameRuleFile grf = reader.FromFile(filename);
    
    var options = new JsonSerializerOptions();
    options.WriteIndented = true;
    var json = JsonSerializer.Serialize(grf.Root.ChildRules, options);
    
    File.WriteAllText(filename+".json", json);
    Console.WriteLine("Processed "+filename);
}