using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace lmao
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String fileName;
			String classification, name, expressionSystem, organismName;

			Console.WriteLine ("Enter name of file: ");
			fileName = Console.ReadLine();
			fileName += ".pdb.txt";

			String header = "HEADER";
			String title = "TITLE";
			String expsys = "EXPRESSION_SYSTEM:";
			String organism = "ORGANISM_SCIENTIFIC:";

			if (File.Exists (fileName)) {

				StreamReader reader = new StreamReader (fileName);
				String line = reader.ReadLine ();

				classification = findInfo (header, fileName, line, reader);
				Console.WriteLine (classification);

				name = findInfo (title, fileName, line, reader);
				Console.WriteLine (name);

				organismName = findExpression (organism, fileName, line, reader);
				Console.WriteLine (organismName);

				expressionSystem = findExpression (expsys, fileName, line, reader);
				Console.WriteLine (expressionSystem);


			}
			else
				Console.WriteLine("file does not exist");
		}


		static String findInfo(String text, String fileName, String line, StreamReader reader ){
			while (!line.StartsWith (text))
				line = reader.ReadLine ();
			String noSpace;
			noSpace = Regex.Replace(line, " {2,}", " ");
			String head = noSpace.Substring(text.Length + 1, noSpace.Length - text.Length - 1);

			return Regex.Replace (head, "[^a-zA-Z ]", "");
		}

		static String findExpression(String text, String fileName, String line, StreamReader reader){
			int index = line.IndexOf (text);
			while (index == -1) {
				line = reader.ReadLine ();
				index = line.IndexOf (text);
			}
			int end = line.IndexOf (";");

			String substring = line.Substring (index + text.Length + 1, end - text.Length);
			return substring.Substring(0, substring.Length - 12);
		}	
	}
}
