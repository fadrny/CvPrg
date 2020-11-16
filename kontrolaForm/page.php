<?php
function formular($warn, $nazev, $pkusu, $cena, $pop, $obch, $mail){
    $out = "<!DOCTYPE html><head><title>Formular</title><style>#spatneZadany{outline: 2px solid #ff0000;}</style></head>";
    $out .= "<form method='post' action='index.php'>";

    $outlineId = "";
    if($warn && $nazev == ""){$outlineId = "id='spatneZadany'";}else{$outlineId = "";}
    $nazevp = hpa($nazev);
    $out .= "<label for=\"fjmeno\">Nazev:</label><br>
             <input $outlineId type=\"text\" name=\"fjmeno\" value=\"$nazevp\"><br>";

    if($warn && $pkusu == ""){$outlineId = "id='spatneZadany'";}else{$outlineId = "";}
    $pkusup = hpa($pkusu);
    $out .= "<label for=\"fpcs\">Pocet kusu:</label><br>
             <input $outlineId type=\"number\" name=\"fpcs\" value=\"$pkusup\"><br>";

    if($warn && $cena == ""){$outlineId = "id='spatneZadany'";}else{$outlineId = "";}
    $cenap = hpa($cena);
    $out .= "<label for=\"fcena\">Cena:</label><br>
             <input $outlineId type=\"number\" step='any' name=\"fcena\" value=\"$cenap\"><br>";

    if($warn && $pop == ""){$outlineId = "id='spatneZadany'";}else{$outlineId = "";}
    $popp = hpa($pop);
    $out .= "<label for=\"fpop\">Popis:</label><br>
             <textarea $outlineId name=\"fpop\" rows=\"4\" cols=\"50\">
                $popp
             </textarea><br>";

    if($warn && $obch == ""){$outlineId = "id='spatneZadany'";}else{$outlineId = "";}
    $obchp = hpa($obch);
    $out .= "<label for=\"fobch\">Obchodnik:</label><br>
             <input $outlineId type=\"email\" name=\"fobch\" value=\"$obchp\"><br>";

    if($warn && $mail === ""){$outlineId = "id='spatneZadany'";}else{$outlineId = "";}
    $out .= "<label for=\"fmail\">Zasilat maily:</label><br>
             <input $outlineId type=\"checkbox\" name=\"fmail\" value=\"\"";

    if($mail == true){
        $out .= "checked";
    }

    $out .= "><br>";
    $out .= "<input type=\"submit\" value=\"Poslat\">";


    $out .= "</form></body></html>";
    return $out;
}

function vsechnoOk($nazev, $pkusu, $cena, $pop, $obch, $mail){
    $out = "<!DOCTYPE html><head><title>Zvladl jsi to</title><style>#spatneZadany{outline: 2px solid #ff0000;}</style></head><body>";


    $out .= "<p><b>Název:</b> $nazev</p>";
    $out .= "<p><b>Počet kusů:</b> $pkusu</p>";
    $out .= "<p><b>Cena:</b> $cena</p>";
    $out .= "<p><b>Popis:</b> $pop</p>";
    $out .= "<p><b>Obchodnik:</b> $obch</p>";
    $out .= "<p><b>Zasílat maily:</b> ";
    if($mail)
        $out .= "Ano";
    else
        $out .= "Ne";
    $out .= "</p>";


    $out .= "</body></html>";
    return $out;
}

function hpa($in){
    return htmlspecialchars($in);
}