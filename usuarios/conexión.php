<?php
try
{
  $pdo = new PDO('mysql:host=localhost;dbname=usuarios' , 'unity' , 'onTx_OyvzMTS@fKz');
  $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
  $pdo->exec('SET NAMES "utf8"');
}
catch (PDOException $e)
{
  echo "ERROR CONNECTING TO DATABASE " . $e->getMessage();
  exit();
}
echo "Conexión exitosa."
  ?>
