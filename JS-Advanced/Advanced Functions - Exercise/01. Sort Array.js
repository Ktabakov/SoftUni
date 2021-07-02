function solve(nums, task){
    task === `asc`
    ? nums.sort((a, b) => a - b)
    : nums.sort((a, b) => b - a)

    return nums;
};

solve([14, 7, 17, 6, 8], 'asc');
solve([14, 7, 17, 6, 8], 'desc');