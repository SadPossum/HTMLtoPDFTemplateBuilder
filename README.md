# HTMLtoPDFTemplateBuilder
 
HTMLtoPDFTemplateBuilder is a small library that generates a PDF file from an HTML template with the ability to replace text, generate barcodes, QR codes and more ...

## HTML example:
```html
<html>

<head>
    <meta charset="UTF-8">
</head>

<body>
    <name>placeholder</name>
    <qr_code charset="UTF-8" errorcorrection="L">placeholder</qr_code>
    <barcode class="barcode-class">placeholder</barcode>
</body>

<style>
    qr_code {
        height: 100px;
        width: 100px;
        border: solid 1px red;
    }

    .barcode-class {
        height: 55px;
        width: 75%;
        border: solid 1px red;
    }

    name {
        font-family: "Times New Roman", Times, serif;
        font-size: 20px;
        border: solid 1px red;
    }


</style>

</html>
```
<br>
HTML tag names cannot contain capital letters and special characters (not sure). You can use "_" to separate words <br>
You can also use CSS. Recomend to writing html and css in one file

## C# code example:
```csharp
var content = new Dictionary<string, (string, PDFContentType)>();
content.Add("name", ("Name", PDFContentType.Text));
content.Add("qr_code", ("Some text", PDFContentType.QRCode));
content.Add("barcode", ("19292928189fff", PDFContentType.Barcode));

byte[] htmlBytes = File.ReadAllBytes(@"C:\Users\EBOI\Desktop\New folder\index.html");

var pdfBytes = PdfCreator.Create(htmlBytes, content);

File.WriteAllBytes(@"C:\Users\EBOI\Desktop\New folder\new.pdf", pdfBytes);
```

## PDF result:
![image](https://user-images.githubusercontent.com/61198926/114552868-b3fcf580-9c6d-11eb-8c9f-f2f31f11d0f1.png)
<br>
<br>
Developed jointly with <a href="https://github.com/stillProger">StillProger <img width="20" height="20" src="https://avatars.githubusercontent.com/u/61091044?s=64&v=4"></a> <br>
Developed using itext 7

# RU
HTMLtoPDFTemplateBuilder - это небольшая библиотека, которая генерирует файл pdf из шаблона html с возможностью заменять текст, генерировать штрих-коды, QR-коды и многое другое ...

## Пример HTML:
```html
<html>

<head>
    <meta charset="UTF-8">
</head>

<body>
    <name>placeholder</name>
    <qr_code charset="UTF-8" errorcorrection="L">placeholder</qr_code>
    <barcode class="barcode-class">placeholder</barcode>
</body>

<style>
    qr_code {
        height: 100px;
        width: 100px;
        border: solid 1px red;
    }

    .barcode-class {
        height: 55px;
        width: 75%;
        border: solid 1px red;
    }

    name {
        font-family: "Times New Roman", Times, serif;
        font-size: 20px;
        border: solid 1px red;
    }


</style>

</html>
```
<br>
Имена тегов HTML не могут содержать заглавные буквы и специальные символы (не точно). Для разделения слов можно использовать "_" <br>
Вы также можете использовать CSS. Лучше писать html и css в один файл

## Пример кода C#:
```csharp
var content = new Dictionary<string, (string, PDFContentType)>();
content.Add("name", ("Name", PDFContentType.Text));
content.Add("qr_code", ("Some text", PDFContentType.QRCode));
content.Add("barcode", ("19292928189fff", PDFContentType.Barcode));

byte[] htmlBytes = File.ReadAllBytes(@"C:\Users\EBOI\Desktop\New folder\index.html");

var pdfBytes = PdfCreator.Create(htmlBytes, content);

File.WriteAllBytes(@"C:\Users\EBOI\Desktop\New folder\new.pdf", pdfBytes);
```

## PDF результат:
![image](https://user-images.githubusercontent.com/61198926/114552887-b8c1a980-9c6d-11eb-88a3-6b1d43e26657.png)
<br>
<br>
Библиотека разработана совместно с <a href="https://github.com/stillProger">StillProger <img width="20" height="20" src="https://avatars.githubusercontent.com/u/61091044?s=64&v=4"></a> <br>
Разработано с использованием itext 7