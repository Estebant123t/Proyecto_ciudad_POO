<?php
include "conexión.php";

$username = $_POST['username'];
$pass = hash("sha256", $_POST['pass']);

$sql = "SELECT username from usuarios WHERE username = '$username'";
$result = $pdo->query($sql);

if ($result->rowCount() > 0)
{
  $data = array('done' => false, 'message' => "Nombre de usuario ya existente.");
  Header('Content-Type: application/json');
  echo json_enconde($data);
  exit();
}
else
{
  $sql = "INSERT INTO usuarios SET Name = '$username', Pass = '$pass'";
  $pdo->query($sql);

    $data = array('done' => true, 'message' => "Resgistro exitoso.");
    Header('Content-Type: application/json');
    echo json_enconde($data);
    exit();


}

 ?>
