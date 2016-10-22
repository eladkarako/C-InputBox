using System;
using Microsoft.VisualBasic;

namespace inputbox
{
  class Program
  {
    public static void Main(string[] args)
    {
      string sPrompt = "";
      string sTitle = "";
      string sDefault = "";
      
      foreach (string arg in args) {
        string tmp = arg.Trim();
        
        if (tmp.StartsWith("-prompt=", StringComparison.CurrentCultureIgnoreCase))
          sPrompt = tmp.Replace("-prompt=", "").Replace("\"", "").Replace("\r", "").Replace("\\n", "\n").Replace("\\t", "    ");
        else if (tmp.StartsWith("-title=", StringComparison.CurrentCultureIgnoreCase))
          sTitle = tmp.Replace("-title=", "").Replace("\"", "").Replace("\r", "").Replace("\\n", "\n").Replace("\\t", "    ");
        else if (tmp.StartsWith("-default=", StringComparison.CurrentCultureIgnoreCase))
          sDefault = tmp.Replace("-default=", "").Replace("\"", "").Replace("\r", "").Replace("\\n", "\n").Replace("\\t", "    ");
      }
      if (sPrompt.Equals("") && sTitle.Equals("") && sDefault.Equals("")) {
        Console.Error.WriteLine("Error: missing -prompt=\"..\" or -title=\"..\" or -default=\"..\"");
      } else {
        Console.WriteLine(
          Microsoft.VisualBasic.Interaction.InputBox(sPrompt, sTitle, sDefault)
        );
      }
    }
  }
}