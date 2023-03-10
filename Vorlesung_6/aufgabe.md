# Aufgabe Taschenrechner:

## Level 1:

Entwickle einen Taschenrechner:
- Der Taschenrechner besitzt zwei Textboxen für die Eingabe von 2 Zahlen.
- Der Taschenrechner besitzt einen Button durch den die zwei Zahlen geteilt werden können.
- Das Ergebnis der Berechnung soll in einem Label angezeigt werden.
- Bei einem Fehler soll eine sprechende Fehlermeldung in einem weiteren Label angezeigt werden.

Randbedingungen sind:
- Der Rechner muss eine Fehlermeldung beim versuch einer Berechnung geben:
  - wenn nur eins der beiden Textfelder ausgefüllt ist.
  - wenn versucht wird durch 0 zu teilen. 
- Im Fehlerfall muss der Rechner die letzte Berechnung aus dem Ergebnislabel löschen.
- Der Rechner muss die Textfelder bei einer erfolgreichen! Berechnung leer machen.
- Der Rechner muss die letzte Fehlermeldung löschen bei erfolgreicher Berechnung.

>Achtung: denk daran das du Datentypen konvertieren muss!


## Level 2:

- Ergänze die restlichen 3 Rechenoperationen
  - Addition
  - Subtraktion
  - Multiplikation
- Ermögliche es dem Bediener, dass er durch einen Knopfdruck den ausgerechneten Wert entweder in das erste oder zweite Inputfeld kopieren kann.


## Level 3:

Erstelle ein zweites Fenster.
In diesem Fenster gibt es nur noch ein Inputfeld.
Zusätzlich gibt es einen berechnen Button.
Im Inputfeld werden mathematische Ausdrücke eingeben, diese werden beim Drücken vom berechnen Button validiert.
Das Ergebnis wird wieder in einem Label ausgegeben.
Fehlermeldungen sind gleich wie bei Level 1 zu betrachten:
Der Rechner muss folgende Ausdrücke richtig interpretieren können.
- Einfach
  - 3+4 --> 7
  - 0*5.5 --> 0
- Mittel
  - 7 - 3 --> 4 (Beachte das Leerzeichen)
  - 3+4-2 --> 5
  - 2*6+2 --> 14
- Schwer
  - 3+7*2 --> 15
  - 3-1-1- 1-1-1+6 --> 4
  - (6+3)*8 --> 72

