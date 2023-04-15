using UnityEngine;

namespace General_Logic.Variables
{
    [CreateAssetMenu(fileName = "NewCommandModeVariable", menuName = "Data/Variables/CommandModeVariable")]
    public class CommandModeVariable : AbstractVariable<CommandMode>
    {
        
    }
    
    public enum CommandMode
    {
        Excavate,
        TransportLine
    }
}
