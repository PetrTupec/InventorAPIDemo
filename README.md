# InventorApiDemoApp

Tato aplikace je demo projekt vytvořený za účelem seznámení se s **Autodesk Inventor API** a prvním programováním v **C# .NET**.

## Cíl projektu

- Vyzkoušet základní práci s COM objekty v prostředí Autodesk Inventor.
- Získat a zobrazit vybrané informace o modelech `.ipt` a sestavách `.iam`.
- exportovat data do souboru `.json` a `.csv`.

## Průběh běhu aplikace

1. Aplikace spustí novou instanci Autodesk Inventor na pozadí.
2. Uživatel je vyzván k zadání úplné cesty k souboru typu `.ipt` (model) nebo `.iam` (sestava).
3. Po zadání cesty aplikace otevře dokument v Inventoru.
4. Podle typu souboru proběhne:
   - `.ipt`: Načtení a výpis vybraných metadat modelu.
   - `.iam`: Načtení a výpis položek kusovníku (BOM).
5. Aplikace se zeptá uživatele, zda chce pokračovat exportem dat.
   - Pokud uživatel nechce pokračovat, program pokračuje bodem 8.
6. Pokud chce uživatel pokračovat, je vyzván k zadání požadovaného formátu exportu `.json` nebo `.csv`.
7. Po zadání jednoho z podporovaných formátů se data exportují do výstupního souboru.
8. Aplikace ukončí svoji instanci Inventoru a sama se ukončí.

Pokud za běhu programu nastane chyba, aplikace zobrazí chybovou zprávu a bezpečně se ukončí (pokračuje bodem 8).

## Použité technologie

- C# (.NET 8.0)
- Visual Studio Community 2022
- Inventor API

## Požadavky

- Prostředí Windows (testováno na Windows 10)
- Naistalovaný Autodesk Inventor (testováno na české verzi Autodesk Inventor Proffesional 2026)

## Instalace a spuštění

1. Naklonování repozitáře:
   ```bash
   git clone https://github.com/PetrTupec/robot-dashboard-example.git
   ```

2. Otevření projektu ve Visual studiu:
- Je nutné otevřt složku s projekten `InventorAPIDemoApp`

3. Spuštění projektu:
- Tlačítkem play, nebo `ctrl+F5`.

## Možné problémy

- **Pevně nastavený název BOM pohledu ("Strukturované")**:  
  V metodě `DataExtractor.GetBomItems(Document openDocument)` je název BOM pohledu nastaven napevno na `"Strukturované"`, což odpovídá české verzi Inventoru. Pokud aplikaci spustíte s anglickou verzí Inventoru, bude nutné nahradit tento název řetězcem `"Structured"`:
  
  ```csharp
  BOMView bomView = bom.BOMViews["Structured"];
  ```