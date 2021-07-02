function solve(pies, firstPie, lastPie){
    let firstPieIndex = pies.indexOf(firstPie);
    let lastPieIndex = pies.indexOf(lastPie);
    let newPies = pies.slice(firstPieIndex, lastPieIndex + 1);

    return newPies;
}

solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
);

solve(["Apple Crisp", "Mississippi Mud Pie", "Pot Pie", "Steak and Cheese Pie", "Butter Chicken Pie", "Smoked Fish Pie"],
`Pot Pie`,
`Smoked Fish Pie`);