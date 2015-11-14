import os
import xlrd

path = os.getcwd()
files = os.listdir(path)
newpath = path.replace('Data','Technical/Assets/Resources/GameData')
newpath2 = path.replace('Data','Technical/Assets/Scripts/DataSchemes')

files_xlsx = [f for f in files if f[-4:] == 'xlsx']
temp = files_xlsx
print(files_xlsx)
# for f in files_xlsx:
        # wb = xlrd.open_workbook(f)
        # sh = wb.sheet_by_index(0)
        # file = open(os.path.join(newpath ,f.replace('xlsx','txt')),"w")
        # list1 = []

        # for rownum in range(sh.nrows):
            # k = 0
            # for i in sh.row_values(rownum):
                # if ((type(i) == unicode) and rownum == 0):
                    # if not "!" in i:
                        # file.write("\"" + i + "\";")
                        # list1.append(sh.row_values(rownum).index(i))
                # if (type(i) == float and sh.row_values(rownum).index(i) in list1):
                    # if (i % 1 == 0) and k < len(list1):
                        # file.write(str(int(i)) +";")
                        # k += 1
                    # elif k < len(list1):
                        # file.write(str(round(i,3)) + ";")
                        # k += 1
                # else:
                    # if rownum != 0 and sh.row_values(rownum).index(i) in list1:
                        # file.write("\"" + str(i)+ "\";")
                        # k += 1
            # file.write("\n")
        # file.close()
for f in temp:
        if f.startswith("~"):
            print 'skip file : ' + f;
            continue;
        wb = xlrd.open_workbook(f)
        sh = wb.sheet_by_index(0)

        #############################################
        #           GENERATE *.cs                   #
        #############################################
        csFilePath = os.path.join(newpath2 ,f.replace('xlsx','cs'))
        file = open(csFilePath,"w")
        listFieldIndex = []
        listFieldName = []
        listFieldType =[]
        className = f.replace('.xlsx','')
        file.write("using System;\n")
        file.write("public class " + className + " : ICloneable\n")
        file.write("{\n")
        file.write("\tpublic " + className + "(){}\n\n")
        file.write("\tpublic object Clone(){return this.MemberwiseClone();}\n\n")
        file.write("\tpublic " + className +" Copy(){return this.Clone() as " + className + ";}\n\n")

        firstRow = sh.row_values(0);
        secondRow = sh.row_values(1);
        for i in range(0, len(firstRow)):
            fieldName = firstRow[i]
            fieldType = secondRow[i]
            if(not "!" in fieldName): #field hop le
                listFieldIndex.append(i)
                listFieldName.append(fieldName)
                listFieldType.append(fieldType)
                
                file.write("\tpublic {0} {1};\n".format(fieldType, fieldName))

          
        file.write("}")
        file.close()
        
        print ("complete " + csFilePath)
        
        #############################################
        #           GENERATE *.txt                  #
        #############################################
        
        txtFile = os.path.join(newpath ,f.replace('xlsx','txt'));
        file = open(txtFile,"w")
        
        #write header
        for i in range(0, len(listFieldName)):
                        file.write("\"{0}\";".format(listFieldName[i]))
        file.write("\n")
        
        #write data.
        for rownum in range(2,sh.nrows):
            #ghi tung row.
            dataRow = sh.row_values(rownum)
            for i in range(0, len(listFieldIndex)):
                fieldIndex = listFieldIndex[i]
                fieldType = listFieldType[i]
                fieldValue = dataRow[fieldIndex]
                                
                if fieldType == "int":
                    fieldValue = str(int(fieldValue))
                elif fieldType == "float":
                    fieldValue = str(fieldValue)
                else:
                    fieldValue = "\"{0}\"".format(fieldValue)
                
                file.write(str(fieldValue) + ";")
            file.write("\n")
        file.close();
        
