﻿<!--
    General theme component for all UI elements. Must be imported for the UI to work.
-->
<component>
    <template>
        <stylesheet>
            <!-- General -->
            <style 
                    class="text"
                    textfont="{{ Theme.UI_TextPrimary }}" 
                    textcolor=""
                    textsize=""
            />
            
            <style 
                    class="bg-primary"
                    bgcolor="{{ Theme.UI_BackgroundPrimary }}"
            />

            <style
                    class="bg-secondary"
                    bgcolor="{{ Theme.UI_BackgroundSecondary }}"
            />
            
            <!-- Buttons -->
            <style 
                    class="btn-default" 
                    textfont="{{ Theme.UI_Font }}" 
                    textcolor="{{ Theme.UI_Button_Default_Text }}"
                    textsize="{{ Theme.UI_FontSize }}"
                    bgcolor="{{ Theme.UI_Button_Default_Bg }}"
                    bgcolorfocus="{{ Theme.UI_Button_Default_BgFocus }}"
                    focusareacolor1="00000000"
                    focusareacolor2="ffffff22" />
            <style 
                    class="btn-secondary" 
                    textfont="{{ Theme.UI_Font }}"
                    textcolor="{{ Theme.UI_Button_Secondary_Text }}"
                    textsize="{{ Theme.UI_FontSize }}"
                    bgcolor="{{ Theme.UI_BackgroundSecondary }}"
                    bgcolorfocus="{{ Theme.UI_Button_Secondary_BgFocus }}"
                    focusareacolor1="00000000"
                    focusareacolor2="ffffff22"/>
            <style
                    class="btn-disabled"
                    textfont="RajdhaniMono"
                    textcolor="ffffff"
                    textsize="1.5"
                    bgcolor="999999" />
            <style
                    class="btn-secondary-disabled"
                    textfont="RajdhaniMono"
                    textcolor="9798A2"
                    textsize="1.5"
                    bgcolor="E8E8EA" />
            
            <!-- Text Fields -->
            <style 
                    class="textinput-default"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    textcolor="ffffff"
                    bgcolor="{{ Theme.UI_BackgroundSecondary }}"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />

            <style
                    class="textinput-outline-default"
                    bgcolor="ffffff"
            />
            
            <!-- Toggle Switch -->
            <style 
                    class="toggleswitch-on-default"
                    bgcolor="ff0058"
                    textcolor="ff0058"
            />
            
            <style
                    class="toggleswitch-off-default"
                    bgcolor="47495A"
                    textcolor="47495A"
            />
            
            <!-- Checkbox -->
            <style
                    class="checkbox-default"
                    bgcolor="ff0058"
                    textcolor="ff0058"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    bgcolorfocus="ff0058"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />
            <style
                    class="checkbox-outline-default"
                    bgcolor="ff0058"
                    bgcolorfocus="ff0058"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />
            
            <!-- Radio Button -->
            <style 
                    class="radiobutton-default"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    textcolor="ff0058"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />
            
            <!-- Window -->
            <style 
                    class="window-bg-default"
                    bgcolor="47495A"
            />

            <style
                    class="window-bg-secondary"
                    bgcolor="47495A"
            />
            
            <style 
                    class="window-header-default"
                    bgcolor="{{ Theme.UI_BackgroundPrimary }}"
                    bgcolorfocus="FF5B95"
            />

            <style
                    class="window-header-secondary"
                    bgcolor="47495A"
                    bgcolorfocus="FF5B95"
            />
            
            <style
                    class="window-title-default"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    textcolor="{{ Theme.UI_TextPrimary }}"
            />

            <style
                    class="window-title-secondary"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    textcolor="{{ Theme.UI_TextSecondary }}"
            />
            
            <style 
                    class="window-closebtn-default"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    textcolor="{{ Theme.UI_TextPrimary }}"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />

            <style
                    class="window-closebtn-secondary"
                    textsize="1.5"
                    textfont="RajdhaniMono"
                    textcolor="{{ Theme.UI_TextSecondary }}"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />

            <style
                    class="window-minimizebtn-default"
                    textsize="2"
                    textfont="RajdhaniMono"
                    textcolor="{{ Theme.UI_TextPrimary }}"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />

            <style
                    class="window-minimizebtn-secdonary"
                    textsize="2"
                    textfont="RajdhaniMono"
                    textcolor="{{ Theme.UI_TextSecondary }}"
                    focusareacolor1="00000000"
                    focusareacolor2="00000000"
            />
        </stylesheet>
    </template>
</component>
