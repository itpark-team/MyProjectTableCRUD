using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectTableCRUD
{
    internal class ScreenRendering
    {
        protected static int WindowWidth = 120;
        protected static int WindowHeight = 50;

        private PositionMenu positionMenu;
        private int positionYDataItem = 4;


        public override string ToString()
        {
            return positionMenu.ToString();
        }

        public ScreenRendering()
        {
            positionMenu = new PositionMenu() { };
            Console.SetCursorPosition(positionMenu.X, positionMenu.Y);
        }
        //установить курсор
        //выбрать пункт меню и нарисовать
        //передвинуть курсор
        internal struct PositionMenu
        {
            internal int X { get; private set; }
            internal int Y { get; private set; }

            public PositionMenu()
            {
                X = 0;
                Y = 1;
            }

            public override string ToString()
            {
                return $"x={X}, y={Y}";
            }

            internal void SetDefaultPosition()
            {
                X = 0;
                Y = 1;
            }

            public void SetPosition(int x = 0, int y = 0)
            {
                X += x;
                Y += y;
            }
        }

        private void SetCursorMenu(int lenght)
        {
            positionMenu.SetPosition(x: lenght);

            Console.SetCursorPosition(positionMenu.X, positionMenu.Y);
        }

        private void SetColorMenu(bool select)
        {
            if (select)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else 
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;
            }

        }

        private void SetColorDataItemNoteSelect()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void SetColorDataItemSelected()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private void DrawHorizontalGapMenu()
        {
            string horizontalGap = "  ";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("");
            SetCursorMenu(4);
        }

        public void DrawMenu(MenuItem[] menuItems)
        {
            Console.Write("Pres '<-' or '->' from select menu item. Esc to exit.");
            DrawHorizontalGapMenu();
            for (int i = 0; i < menuItems.Length; i++)
            {

                if (menuItems[i].IsFocus == true)
                {
                    DrawMenuItem(menuItems[i].Name, menuItems[i].IsFocus);
                }
                else
                {
                    DrawMenuItem(menuItems[i].Name);
                }
                DrawHorizontalGapMenu();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        private void DrawMenuItem(string str, bool isSelected = false)
        {
            SetColorMenu(isSelected);
            Console.Write(str);
            SetCursorMenu(str.Length);
        }

        private void DrawItemData(ref Person dataPerson)
        {
            Console.SetCursorPosition(1, positionYDataItem);
            Console.Write(dataPerson);
            positionYDataItem++;
        }
        public void DrawListData(Person[] dataItemsPerson, int indexSelectedData)
        {
            if (dataItemsPerson != null)
            {
                for (int i = 0; i < dataItemsPerson.Length; i++)
                {
                    SetColorDataItemNoteSelect();
                    if (i == indexSelectedData)
                    {
                        SetColorDataItemSelected();
                    }

                    DrawItemData(ref dataItemsPerson[i]);
                }
            }

            positionYDataItem = 4;
        }


        public void Clean()
        {
            Console.Clear();
            positionMenu.SetDefaultPosition();
            Console.Write("");
        }



        //for (int i = 0; i < 4; i++)
        //{
        //    if (i == 1)
        //    {
        //        SetCursor(  PrintString.Length);
        //        SetColor(true);
        //    }
        //    else
        //    {
        //        SetCursor(PrintString.Length);
        //        SetColor(false);
        //    }

        //    Console.WriteLine(PrintString);
        //     DrawHorizontalGap();
        //}

        //Console.BackgroundColor = ConsoleColor.Black;
        //Console.ForegroundColor = ConsoleColor.White;
        //positionMenu.X = str.Length + 2;
        //positionMenu.Y = 2;




    }
}
