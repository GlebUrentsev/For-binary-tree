using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_binary_tree
    {
    public enum Way_use {ClASSES, CONSTS, VARS,METHODS }  // способ использования ( класс, метод...)
    public enum Type {float_type,bool_type, char_type, string_type, class_type,int_type}; // тип 
    public enum Method_type {param_val, param_ref, param_out}; // тип передачи параметра

    public abstract class Class_Identificator
    {
        public string Name { get; set; }
        public int HashCode { get { return Name.GetHashCode(); } }
        public Way_use Way_use { get; set; }
        public Type Type { get; set; }

        public Class_Identificator(string _name, string _type) 
        {
            Name = _name;          
            switch (_type)
            {
                case "int":
                    Type = Type.int_type;
                    break;
                case "float":
                    Type = Type.float_type;
                    break;
                case "bool":
                    Type = Type.bool_type;
                    break;
                case "char":
                    Type = Type.char_type;
                    break;
                case "string":
                    Type = Type.string_type;
                    break;
                case "class":
                    Type = Type.class_type;
                    break;
            }
        }
    }
    public class Vars: Class_Identificator
    {
        public Vars(string _name, string _type) : base(_name, _type)
        {
            Way_use = Way_use.VARS;
        }
    }
    public class Classes : Class_Identificator
    {
        public Classes(string _name, string _type) : base(_name, _type)
        {
            Way_use = Way_use.ClASSES;
        }
    }
    public class Consts : Class_Identificator
    {
        public object Value { get; set; }
        public Consts(string _name, string _type, object _value) : base(_name, _type)
        {
            Value = _value;
            Way_use = Way_use.CONSTS;
        }
    }

    public class Methods : Class_Identificator
    {
        public LinkedList<List_methods> Parametr { get; set; }
        public Methods(string _name, string _type, LinkedList<List_methods> par) : base(_name, _type)
        {
            Parametr = par;
            Way_use = Way_use.METHODS;
        }
    }   
}
