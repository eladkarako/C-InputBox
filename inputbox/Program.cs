//-----------------------------------------------------------------------
// <copyright file="Program.cs" author="Elad Karako" company="no">
//     UnLicensed (Public Domain).
// </copyright>
//-----------------------------------------------------------------------
namespace InputBox
{
  using System;
  using Microsoft.VisualBasic;

  /// <summary>
  /// Alerts a user with a GUI InputBox (based on VB library) then passes the information to the console.
  /// </summary>
  public sealed class Program
  {
    /// <summary>
    /// Prevents a default instance of the <see cref="Program"/> class from being created.
    /// </summary>
    private Program()
    {
    }

    /// <summary>
    /// Main and single-action.
    /// </summary>
    /// <param name="args">arguments from the operation-system.</param>
    /// <returns>exit-code (0 any arguments were available, or 1 no arguments specified).</returns>
    public static int Main(string[] args)
    {
      string info_prompt = string.Empty;
      string info_title = string.Empty;
      string info_default = string.Empty;
      
      foreach (string arg in args) 
      {
        string tmp = arg.Trim();
        
        if (tmp.StartsWith("-prompt=", StringComparison.CurrentCultureIgnoreCase)) 
        {
          info_prompt = tmp.Replace("-prompt=", string.Empty).Replace("\"", string.Empty).Replace("\r", string.Empty).Replace("\\n", "\n").Replace("\\t", "    ");
        }
        else if (tmp.StartsWith("-title=", StringComparison.CurrentCultureIgnoreCase)) 
        {
          info_title = tmp.Replace("-title=", string.Empty).Replace("\"", string.Empty).Replace("\r", string.Empty).Replace("\\n", "\n").Replace("\\t", "    ");
        } 
        else if (tmp.StartsWith("-default=", StringComparison.CurrentCultureIgnoreCase))
        {
          info_default = tmp.Replace("-default=", string.Empty).Replace("\"", string.Empty).Replace("\r", string.Empty).Replace("\\n", "\n").Replace("\\t", "    ");
        }
      }

      if (string.IsNullOrEmpty(info_prompt) && string.IsNullOrEmpty(info_title) && string.IsNullOrEmpty(info_default)) 
      {
        Console.Error.WriteLine("Error: missing -prompt=\"..\" or -title=\"..\" or -default=\"..\"");
        Environment.ExitCode = 1;
      } 
      else 
      {
        Console.WriteLine(Microsoft.VisualBasic.Interaction.InputBox(info_prompt, info_title, info_default, -1, -1));
        Environment.ExitCode = 0;
      }

      return Environment.ExitCode;
    }
  }
}