using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace For_binary_tree
{
    class FIleParser
    {
        private static string Var_Reader = @"^(?<type>\w+)\s(?<name>\w+);$";       
        private static string Class_Reader = @"^class\s(?<name>\w+);$";
        private static string Const_Reader = @"^const\s(?<type>\w+)\s(?<name>\w+)\s=\s(?<value>[a-zA-Z0-9\.'""]+);$";
        private static string Method_Reader = @"^(?<type>\w+)\s(?<name>\w+)\((?<params>.*)\);$";
        private static string MethodParam_Reader = @"((?<paramType>\w+)\s)?(?<type>\w+)\s\w+";


        public static BinaryTree Parse(string[] lines)
        {

            BinaryTree tree = new BinaryTree();
            foreach (string line in lines)
            {
                if (Regex.IsMatch(line, Var_Reader))
                {
                    Regex regex = new Regex(Var_Reader);
                    Match match = regex.Match(line);

                    string type = match.Groups["type"].Value;
                    string name = match.Groups["name"].Value;

                    Vars new_var = new Vars(name, type);
                    tree.Insert(new_var);
                }

                else if (Regex.IsMatch(line, Class_Reader))
                {
                    Regex regex = new Regex(Class_Reader);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;

                    Classes new_class = new Classes(name, "class");
                    tree.Insert(new_class);
                }

                else if (Regex.IsMatch(line, Const_Reader))
                {
                    Regex regex = new Regex(Const_Reader);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;

                    object value;
                    if (type == "float")
                        value = float.Parse(match.Groups["value"].Value.Replace('.', ','));
                    else if (type == "int")
                        value = int.Parse(match.Groups["value"].Value);
                    else if (type == "string")
                        value = match.Groups["value"].Value.Replace(@"""", string.Empty);
                    else if (type == "bool")
                    {
                        if (match.Groups["value"].Value == "false")
                            value = false;
                        else
                            value = true;
                    }
                    else value = match.Groups["value"].Value[1];

                    Consts new_const = new Consts(name, type, value);
                    tree.Insert(new_const);
                }

                else if (Regex.IsMatch(line, Method_Reader))
                {
                    Methods new_method;
                    Regex regex = new Regex(Method_Reader);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;

                    if (match.Groups["params"].Value == String.Empty)
                    {
                        new_method = new Methods(name, type,null);
                        tree.Insert(new_method);
                        continue;
                    }

                    string[] parameters = match.Groups["params"].Value.Split(',');
                    regex = new Regex(MethodParam_Reader);


                    var list_param = new LinkedList<List_methods>();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Match parameterMatch = regex.Match(parameters[i].Trim());
                        string parameterType = parameterMatch.Groups["type"].Value;

                        Method_type param_type = Method_type.param_val;

                        if (parameterMatch.Groups["paramType"].Value != String.Empty)
                            switch (parameterMatch.Groups["paramType"].Value)
                            {
                                case "ref":
                                    param_type = Method_type.param_ref;
                                    break;
                                case "out":
                                    param_type = Method_type.param_out;
                                    break;
                            }
                        list_param.Add(new List_methods(parameterType, param_type));
                    }

                    var method = new Methods(name, type, list_param);
                    tree.Insert(method);
                }
            }
           return tree;
        }

    }
}
