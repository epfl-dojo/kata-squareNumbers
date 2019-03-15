<?php

$size = $argv[1];

function row($size){
  print " row : $size * $size\n";
  $total = $size * $size;
  $current = $size;
  for ($i=1; $i <= $total; $i++) {
    print sprintf(" %'.02d"," $i");
    if($i == $current) {
      $current += $size;
      print "\n";
    }
  }
}

function column($size){
  print " column : $size * $size\n";
  $total = $size * $size;
  $counter = $size;
  for ($i=1; $i <= $size ; $i++) {
    print sprintf(" %'.02d"," $i");
    $current = $i;
    for ($j=1; $j < $counter ; $j++) {
      $current += $size;
      print sprintf(" %'.02d"," $current");
    }
    print"\n";
  }
}
// to do
// function spiral($size){
//   $total = $size * $size;
//   $numbers = [];
//   for ($i=0; $i <= $total; $i++) {
//     $numbers[$i] = $i;
//     for ($j=0; $j <= $size; $j++) {
//       $numbers[$j] = $j;
//     }
//   }
//
//   foreach ($numbers as $k => $v) {
//     if($v === 0){
//       continue;
//     }
//     print $v;
//     if ($k % $size == 0){
//       print "\n";
//     }
//   }
// }

row($size);
print "\n\n";
column($size);
print "\n\n";
//spiral($size);
