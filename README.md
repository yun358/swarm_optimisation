# swarm_optimisation

We create a swarm with following properties:
- inertial weight w from [0,1]
- particle acceleration coefficient c_p from [1,2]
- swarm coefficient c_s from [1,2]
- number of particles n
- vector s_best which is the position of the minimum value found across the entire swarm
- m, number of steps taken in the algorithm

By populating the swarm with n particles, each particle has
- vector of current position x, which has random initial value in the problem domain
- vector of current velocity v, with random initial value a fraction of the size of the problem domain
- vector p_est that is the position of the minimum value found up until this point in time by the particle

We begin the algorithm by finding and assigning s_best, the initial value of p_best for each particle is its initial
value of x

At each time step, we update the velocity of each particle with

v_{t+1} = w(v_t) + (c_p)(r_p)(p_{best} - x_t) + (c_s)(r_2)(s_{best} - x_t) 

where r_1 and r_2 are randomly chosen from [0, 1]

We update the position of each particle with

x_{t+1} = x_t + v_{t+1}

We update the p_{best} value of each particle if necessary and the s_{best} value of the swarm if necessary

Example functions being optimised, we find the arguments that minimise these functions:

f(x,y) = (x-1)^2 +10(x^2 - y^2), -1<=x<=1.5, -1<=y<=1.5

f(x,y) = xe^(-(x^2 + y^2)), -2<=x<=2, -2<=y<=2
