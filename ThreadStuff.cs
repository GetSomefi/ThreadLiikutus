class BackAndForth{
    int curPos = 0;

    string line;
    int rows;

    int PressedKeyValueX {get;set;}
    int PressedKeyValueY {get;set;}

    public BackAndForth(string _line, int _rows){
        line = _line;
        rows = _rows;
    }

    public void DrawLine(){
        int[] pos1 = {0,0};
        int[] pos2 = {0,0};
        do{
            Console.Clear();
            (string,int) newLine1 = Move(pos1[0],'|');
            pos1[0] = newLine1.Item2;
            Console.WriteLine(newLine1);

            pos2[1] += PressedKeyValueY;
            PressedKeyValueY = 0; 

            for (int i = 0; i < rows; i++){
                Func<int,char> charToShow = (_i) => { 
                    char r = '-';
                    if(_i==pos2[1]) r = '#'; 
                    return r;
                };
                (string,int) newLine2 = Move(pos2[0] + PressedKeyValueX,charToShow(i),false);
                PressedKeyValueX = 0;
                pos2[0] = newLine2.Item2;
                Console.WriteLine(newLine2);   
            }

            Thread.Sleep(100);
        }while(true);
    }

    public void GetKeyStrokes(){
        do
        {
            ConsoleKey key = Console.ReadKey().Key;
            if(key == ConsoleKey.LeftArrow){
                PressedKeyValueX = -1;
            }
            else if(key == ConsoleKey.RightArrow){
                PressedKeyValueX = 1;
            }
            else if(key == ConsoleKey.UpArrow){
                PressedKeyValueY = -1;
            }
            else if(key == ConsoleKey.DownArrow){
                PressedKeyValueY = 1;
            }
        } while (true);
    }

    bool dir = true;
    (string,int) Move(int curPos, char charToMove, bool autoMove = true){
        
        //do{
            //line[curPos] = charToMove; 
            char[] charLine = line.ToCharArray();
            charLine[curPos] = charToMove; // index starts at 0!
            string newLine = new string (charLine);
            
            //DrawLine(newLine);
            //Thread.Sleep(100);

            if(autoMove){
                if(curPos < line.Length-1 && dir){
                    curPos++;
                }else{
                    dir = false;
                }

                if( curPos > 0 && !dir){
                    curPos--;
                }else{
                    dir = true;
                }   
            }
        //}while(true);
        return (newLine,curPos);
    }

}