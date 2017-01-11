# MWPC (Munin Windows Performance Counter)

Bei Munin Windows Performance Counter (MWPC) handelt es sich um einen für Windows Systeme geschriebenen Munin Node-Service. Dieser liefert Messdaten der gewählten Leistungsindikatoren an abfragende Munin Server, um sie dort graphisch darzustellen.

Features
--------
 - Freie Auswahl unter allen Leistungsindikatoren des Systems
 - Umfangreiche Gestaltungsmöglichkeiten der graphischen Datendarstellungen (Beschriftung der Y-Achse, Titel, etc.)
 - Windows Dienst, der automatisch beim Systemstart gestartet wird
 - MWPC Selector: Graphisches Programm zur Auswahl und Anpassung der Leistungsindikatoren
 - MWPC Debug: Programm zur Fehleranalyse

Systemvoraussetzungen
---------------------
 - Windows Vista, 7, 8, 8.1, 10 oder
 - Windows Server 2008, 2008 R2, 2012, 2012 R2, 2016
 - .NET-Framework 4.5
 - Portfreigabe 4949 (TCP)

Kurzanleitung
-------------
 1. Setup starten und Programm installieren
 2. MWPC Selector ausführen und evtl. vorhandene Konfiguration laden (File -> Load)
 3. Gewünschte Performance Counter zur Tabelle hinzufügen
 4. Ausgewählte Performance Counter wie gewünscht anpassen (Titel, Y-Achsenlabel, Multiplikator, etc.)
 5. Konfiguration speichern (File -> Save)
 6. Service (neu)starten (Service -> Restart), alternativ kann der Service auch im Dienst Snap-In neu gestartet werden
