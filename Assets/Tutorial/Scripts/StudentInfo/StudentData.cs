using UnityEngine;

namespace UV.Tutorial.StudentInfo
{
    [System.Serializable]
    public class StudentData 
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public string School { get; set; }

        public StudentData()
        { 
            Name = string.Empty;
            School = string.Empty;  
        }

        public override string ToString()
        {
            return $"{Name} from {School}";
        }
    }
}
