
# ProjektTrail

ProjektTrail ist eine Projektmanagement-App, entwickelt mit .NET MAUI. Die App ermöglicht es den Nutzern, Projekte zu verwalten, einschließlich der Erstellung neuer Projekte, der Anzeige von Projektdetails und der Bearbeitung bestehender Projekte.

## Hauptfunktionen

- **Projektübersicht:** Zeigt eine Liste aller Projekte an.
- **Neues Projekt erstellen:** Ermöglicht das Anlegen neuer Projekte.
- **Projektdetails:** Zeigt Details eines Projekts an und ermöglicht die Bearbeitung.
- **Datenpersistenz:** Projektdaten werden in einer SQLite-Datenbank gespeichert.

## Setup

1. **Klonen des Repositories:**
   ```bash
   git clone https://github.com/Devinoir/ProjecTrail.git
   ```
2. **Öffnen des Projekts in Visual Studio:**
   Navigieren Sie zum geklonten Verzeichnis und öffnen Sie die `.sln`-Datei in Visual Studio.
   
3. **Installieren der erforderlichen NuGet-Pakete:**
   Stellen Sie sicher, dass alle erforderlichen NuGet-Pakete installiert sind, insbesondere `Microsoft.EntityFrameworkCore.Sqlite` für die SQLite-Unterstützung.

4. **Starten der App:**
   Führen Sie die App auf einem Emulator, einem physischen Gerät oder direkt als Windows App aus.

## Nutzung

- **Hauptseite:** Listet alle Projekte auf. Nutzer können ein Projekt auswählen, um Details anzuzeigen, oder auf "Neues Projekt erstellen" klicken, um ein neues Projekt hinzuzufügen.
- **Projektdetailseite:** Zeigt detaillierte Informationen zum ausgewählten Projekt an und ermöglicht die Bearbeitung. (Navigation nicht implementiert)
