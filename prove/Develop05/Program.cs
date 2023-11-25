using System;

class Program
{
    static void Main(string[] args)
    {
        // To exceed requirement for this project
        // I have handled Exceptions from the Menu class,
        // for a checklist goal, I have set a functionality, so when users reach goals a message
        // appears to tell them that the goal has been reached, and they can choose to continue
        // recording by entering whether 'y' or stop with 'n'. You may check it from the line 106.
        Menus menus = new Menus();

        menus.MenusMethod();
    }
}