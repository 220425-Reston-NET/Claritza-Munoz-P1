public interface iMenu
{
    //Display will display choices and Menu they are currently in
    void Display();

    //YourChoice will grab user feeedback and return the menu that should be displayed
    string  YourChoice();
}