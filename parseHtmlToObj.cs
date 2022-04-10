using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VEngine
{
	class parseHtmlToObj
	{
		string htmlText;
		public parseHtmlToObj(string htmlstr)
		{
			htmlText = htmlstr;
		}
		public void deserializeObj() {
			Tags[] tag = new Tags() {tagName = "", tagContent = "" }[10000];
			string tmp = "";//, tmpContent="";
            int tagCount = 0;
			// Get tag name and attributes
			for (int iz = 0; iz < htmlText.Length; iz++)
			{
				if (htmlText[iz] == '<')
				{
					iz++;
					for (int s = iz; htmlText[s] != '>' && s < htmlText.Length; s++)
					{
						tmp += htmlText[s];
					}
                    // "Convert" everything inside '<' and '>' into objects (Tags)
                    // Get tag name
                    for (int j = 0; (tmp[j] != ' ' || tmp[j] != '>' ) && j < tmp.Length; j++)
                        tag.tagName += tmp[j];
                    //get attributes name + content
                    for (int i = tag.tagName.Length + 1; i < tmp.Length; i++)
                    {
                        tg it = new tg();
                        int j = 0, z = 0;
                        for (j = i; tmp[j] != '=' || tmp[j] != ' '; j++)
                            it.name += tmp[j]; //get attr name
                        //check if attribute is "single" or contains something inside " "
                        for (z = j; tmp[z] != '"'; z++) ;
                        for (int x = z+1; tmp[x] != '"'; x++)
                            it.content += tmp[x];
                    }
				}
			}
		}
	}
}
