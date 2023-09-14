<?php
include "Conexión.php";

$usuario = $_POST['usuario'];
$contraseña = hash("sha256", $_POST['contraseña']);

$sql = "SELECT usuario from jugadores WHERE usuario = '$usuario'";
$resul t = $pdo->query($sql);

if ($result->rowCount() > 0)
{
  $data = array('done' => false, 'message' => "Nombre de usuario ya existente.");
  Header('Content-Type: application/json');
  echo json_enconde($data);
  exit();
}
else
{
  $sql = "INSERT INTO jugadores SET NombreUsuario = '$usuario', Contraseña = '$contraseña'";
  $pdo->query($sql);

    $data = array('done' => true, 'message' => "Resgistro exitoso.");
    Header('Content-Type: application/json');
    echo json_enconde($data);
    exit();


}

 ?>
