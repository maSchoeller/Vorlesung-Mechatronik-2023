# Übersicht Wpf

## Controls

### Button

`Button` mit einem Button können Interaktionen ausgelöst werden, die wichtigsten Eigenschaften von einem `Button` sind:
- `Content`: Dort kann z.B. ein Text/Name des Buttons angeben werden.
- `Click`: Mithilfe vom `Click`-Event kann eine Methode definiert werden die bei einem Click aufgerufen wird
Sample
```xml
 <Button Content="Hello World" Click="MeinClickEventhandler"/>
```
Wichtig der `Click`-Eventhandler muss auch in der Codebehind Datei definiert sein!

### TextBox
Mithilfe der Textbox kann man dem Bediener eine Eingabe ermöglichen.
Die Eingabe ist immer ein `string` auch wenn der Bediener einen Zahl eintippt.
Eigenschaften von der Textbox:
- `Text`: der Inhalt der Textbox kann über das Textproperty abgefragt werden.
```xml
<TextBox Text="Textboxinhalt"/>
```

### Label
Ein `Label` ist ein einfaches Textfeld, dass dem Bediener eine Zeichenfolge anzeigen kann.
Eigenschaften des Labels:
- `Content`: der Text der angezeigt werden sol.

```xml
<Label Content="MyFirstLabel"/>
```
