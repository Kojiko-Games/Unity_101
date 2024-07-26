using UnityEngine;

namespace Kojiko.Tutorial.StudentInfo
{
    /// <summary>
    /// Holds information about a student
    /// </summary>
    [System.Serializable]
    public class StudentData
    {
        /// <summary>
        /// The name of the student
        /// </summary>
        [field: SerializeField] public string Name { get; set; }

        /// <summary>
        /// The school of the student
        /// </summary>
        [field: SerializeField] public string School { get; set; }

        /// <summary>
        /// Initializes a new instance of the StudentData class
        /// </summary>
        public StudentData()
        {
            Name = string.Empty;
            School = string.Empty;
        }

        /// <summary>
        /// Returns a string representation of the student's data
        /// </summary>
        /// <returns>A string containing the student's name and school</returns>
        public override string ToString()
        {
            return $"{Name} from {School}";
        }
    }
}
