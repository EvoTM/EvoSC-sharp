<component>
    <import component="EvoSC.Theme" as="Theme" />
    <import component="EvoSC.Window" as="Window" />
    <import component="EvoSC.Controls.Button" as="Button" />
    
    <using namespace="ManiaExchange.ApiClient.Models" />
    
    <property type="TmxMapInfo" name="info" />
    
    <template>
        <Theme/>
        <Window id="mapInfo" title="Add map?">
            <Label y="-5" text="{{ info.GbxMapName }}" />
            <Label y="-10" text="by {{ info.Username }}" />
            <Label y="-15" text="Title-Pack: {{ info.TitlePack }}" />
            <Label y="-20" text="Mood: {{ info.Mood }}" />
            <Label y="-25" text="Single-Lap: {{ info.Laps == 1 }}" />
            <Label y="-30" text="{{ info.Comments }}" />
            <Button x="80" y="-2" id="button_add" text="Add"/>
        </Window>
    </template>

    <script>
        <!--
        *** OnMouseClick ***
        ***
        if (Event.Control.ControlId == "button_add") {
            TriggerPageAction("TmxManialinkController/AddMap/{{ info.TrackID }}");
            CloseWindow("mapInfo");
        }
        ***
        -->
    </script>

    <script resource="EvoSC.Scripts.UIScripts" />
</component>