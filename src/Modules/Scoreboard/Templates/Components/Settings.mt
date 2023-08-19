﻿<component>
    <import component="EvoSC.Controls.Checkbox" as="Checkbox" />
    
    <property type="double" name="w" default="140"/>
    <property type="double" name="h" default="80"/>

    <template>
        <label text="SCOREBOARD SETTINGS" textsize="5" textfont="GameFontBlack" />
        <frame pos="0 -8">
            <label text="Player Settings" textsize="2" textfont="GameFontSemiBold" />
            <Checkbox id="show_flags" y="-6" text="Show country flags" textFont="GameFontRegular" isChecked="{{ true }}" />
            <Checkbox id="show_club_tags" y="-11" text="Show club tags" textFont="GameFontRegular" isChecked="{{ true }}" />
            <Checkbox id="show_echolon" y="-16" text="Show echolon" textFont="GameFontRegular" isChecked="{{ false }}" />
        </frame>
    </template>
    
    <script>
        <!--
        *** OnCheckboxToggle ***
        ***
        if(ControlId == "show_club_tags"){
            declare persistent Boolean TSB_ShowClubTags for LocalUser = True;
            TSB_ShowClubTags = IsChecked;
        }
        ***
        -->
    </script>
</component>