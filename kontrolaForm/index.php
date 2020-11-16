<?php
require "page.php";
$nazev = "";
$pcs = "";
$cena = "";
$pop = "";
$obch = "";
$email = "";

if(empty($_POST)) {
    echo formular(false, $nazev, $pcs, $cena, $pop, $obch, $email);
    exit();
}
else{
    $val = false;

    $checker = filter_input(0,"fjmeno", FILTER_SANITIZE_STRING);
    if(!is_null($checker) && $checker !== false)
        $nazev = $checker;
    else $val = true;

    $checker = filter_input(0,"fpcs", FILTER_VALIDATE_INT, ["options" => ["min_range"=>0]]);
    if(!is_null($checker) && $checker !== false)
        $pcs = $checker;
    else $val = true;

    $checker = filter_input(0,"fcena", FILTER_VALIDATE_FLOAT, ["options" => ["min_range"=>0]]);
    if(!is_null($checker) && $checker !== false)
        $cena = $checker;
    else $val = true;


    if(isset($_POST['fpop'])){
        $mam = $_POST['fpop'];
        $checker = trim(htmlspecialchars(filter_var($mam,FILTER_DEFAULT)));
        if(!is_null($checker) && $checker !== false)
            $pop = $checker;
        else $val = true;
    }
    else $val = true;

    /*
    $checker = filter_input(0,"fpop", FILTER_DEFAULT);
    if(!is_null($checker) && $checker !== false)
        $pop = $checker;
    else $val = true;
    */

    $checker = filter_input(0,"fobch", FILTER_VALIDATE_EMAIL);
    if(!is_null($checker) && $checker !== false)
        $obch = $checker;
    else $val = true;

    $checker = filter_input(0,"fmail", FILTER_VALIDATE_BOOLEAN);
    if(is_null($checker))
        $email = false;
    elseif ($checker === false)
        $email = true;

    if($val)
        echo formular(true, $nazev, $pcs, $cena, $pop, $obch, $email);
    else
        echo vsechnoOk($nazev, $pcs, $cena, $pop, $obch, $email);
    exit();
}


