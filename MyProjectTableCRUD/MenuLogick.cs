using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectTableCRUD
{
    internal class MenuLogick
    {
        private MenuItem[] menuList = new MenuItem[]
        {
            new MenuItem(id: 1, name: "Load", description: "Load file"),
            new MenuItem(id: 2, name: "Save", description: "Save all"),
            new MenuItem(id: 3, name: "Delete", description: "Delete selected"),
            new MenuItem(id: 4, name: "Edit", description: "Edit selected"),
            new MenuItem(id: 5, name: "Exit", description: "Exit program")
        };
        private ScreenRendering screenRendering = new ScreenRendering();

        private Person[] dataItemsArray;

        private bool pressExitProgramm = false;
        private int focusDataItemIndex = 0;

        private enum PressButton
        {
            PressLeft = ConsoleKey.LeftArrow,
            PressRight = ConsoleKey.RightArrow,
            PressUp = ConsoleKey.UpArrow,
            PressDown = ConsoleKey.DownArrow,
            PressEsc = ConsoleKey.Escape,
            PressEnter = ConsoleKey.Enter
        }

        private void Initialize()
        {
            var item = menuList[0];
            item.IsFocus = true;
            menuList[0] = item;
            Persons.GeneratePersonArray(10);
            //dataItemsArray = Persons.GetPersonArray();

        }

        private void ButtonMenuPressed(ref int focusMenuItemIndex, int biasMenu)
        {
            int nextFocusMenuIndex = NextMenuItem(focusMenuItemIndex, menuList, biasMenu);
            SetFocusMenuItem(menuList, focusMenuItemIndex, ref nextFocusMenuIndex);
            focusMenuItemIndex = nextFocusMenuIndex;
        }

        private void ButtonDataPressed(ref int focusDataItemIndex, int biasMenu)
        {
            focusDataItemIndex = NextDataItemFocus(dataItemsArray, ref focusDataItemIndex, biasMenu);
        }

        private void CommandDraw()
        {
            screenRendering.Clean();
            screenRendering.DrawMenu(menuList);
            screenRendering.DrawListData(dataItemsArray, focusDataItemIndex);
        }
        public void Logick()
        {
            Initialize();
            PressButton pressButtons;

            screenRendering.DrawMenu(menuList);
            int focusMenuItemIndex = 0;

            while (!pressExitProgramm)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                pressButtons = (PressButton)keyInfo.Key;
                
                screenRendering.Clean();
                screenRendering.DrawMenu(menuList);
                screenRendering.DrawListData(dataItemsArray, focusDataItemIndex);

                switch (pressButtons)
                {
                    case PressButton.PressLeft:

                        ButtonMenuPressed(ref focusMenuItemIndex, -1);
                        CommandDraw();
                        Console.WriteLine("left");
                        break;

                    case PressButton.PressRight:

                        ButtonMenuPressed(ref focusMenuItemIndex, 1);
                        CommandDraw();
                        Console.WriteLine("right");
                        break;

                    case PressButton.PressEsc:

                        pressExitProgramm = true;
                        Console.WriteLine("escape");
                        // menuList.PressExit(); 
                        break;

                    case PressButton.PressUp:

                        if (dataItemsArray != null)
                        {
                            ButtonDataPressed(ref focusDataItemIndex, -1);
                            CommandDraw();
                        }
                        break;


                    case PressButton.PressDown:
                        if (dataItemsArray != null)
                        {
                            ButtonDataPressed(ref focusDataItemIndex, 1);
                            CommandDraw();
                        }

                        break;

                    case PressButton.PressEnter:
                        PressedEnter(focusMenuItemIndex, focusDataItemIndex);
                        CommandDraw();
                        break;


                }
            }
        }
      
        private void PressedEnter(int intMenuIndex, int intDataIndex)
        {
            if (menuList[intMenuIndex].Id == 1)
            {
                //load file
                if (dataItemsArray != null)
                {
                    dataItemsArray = new Person[0];
                }
                  Persons.DeserializeFile(ref dataItemsArray);
            }

            if (menuList[intMenuIndex].Id == 2)
            {
                //save file
                Persons.SerializeFile(ref dataItemsArray);
            }
            if (menuList[intMenuIndex].Id == 3)
            {
                //delete
                Persons.RemovePersonInArrayByIndex(ref dataItemsArray, intDataIndex);
            }
            if (menuList[intMenuIndex].Id == 4)
            {
                //edit
                Console.WriteLine();
                Console.WriteLine();
                string myString  = Console.ReadLine();
                Persons.UpdateNamePerson(ref dataItemsArray[intDataIndex], myString);
            }
            if (menuList[intMenuIndex].Id == 5)
            {
                //press esc
                Environment.Exit(0);
            }
        }

        private int NextMenuItem(int focusOnMenuItemId, MenuItem[] list, int bias)
        {
            var index = focusOnMenuItemId + bias;//-1
            if (index < 0)
            {
                return list.Length - 1;//5-1=4
            }
            if (index > list.Length - 1)
            {
                return 0;
            }

            return index;



            // int resultLeft = NextMenuItem(focusMenuItemIndex, ref menuList, -1);
        }

        private int NextDataItemFocus(Person[] personsArray, ref int focusDataItem, int biasData)
        {
            if (focusDataItem + biasData < 0)
            {
                return personsArray.Length - 1;
            }

            if (focusDataItem + biasData > personsArray.Length - 1)
            {
                return 0;
            }

            return focusDataItem + biasData;
        }

        //SetFocusMenuItem(ref menuList, focusMenuItemIndex, ref resultLeft);
        //     focusMenuItemIndex = resultLeft;


        private void SetFocusMenuItem(MenuItem[] list, int focusIndex, ref int nextFocusIndex)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (i == focusIndex)
                {
                    var tmp = list[i];
                    tmp.IsFocus = false;
                    list[i] = tmp;

                    var tmp2 = list[nextFocusIndex];
                    tmp2.IsFocus = true;
                    list[nextFocusIndex] = tmp2;

                    break;
                }
            }
        }


    }
}
