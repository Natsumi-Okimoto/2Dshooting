using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCommandManager : MonoBehaviour
{
    private float WaitTime;
    private int CommandIndex;
    private List<ICommand> Command = new List<ICommand>();
    public void Run()
    {
        if (WaitTime > 0) WaitTime--;

        while (CommandIndex < Command.Count && WaitTime == 0)
        {
            Command[CommandIndex].Run();
            CommandIndex++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public interface ICommand
    {
        void Run();
    }

    public class CWaitCommand : ICommand
    {
        private CCommandManager CommandManager;
        private float WaitTime;
        public CWaitCommand(CCommandManager game_control,float wait_time)
        {
            CommandManager = game_control;
            WaitTime = wait_time;
        }

        public void Run()
        {
            CommandManager.WaitTime = WaitTime;
        }
    }


}
