#!/bin/bash

# Define the port forwarding command
command_to_run="kubectl port-forward service/containeraization-sqlserver-service -n kube-system 1438:1438"
time_to_wait="10"

# Function to run the command in the background
run_command() {
    # Run the command in the background
    $command_to_run &
    # Store the process ID of the command
    command_pid=$!
    echo "Port Forward command started with PID: $command_pid"
    # Wait for "time_to_wait" seconds
    sleep $time_to_wait
    # Kill the command process
    kill $command_pid
}

# Infinite loop to run the command periodically
while true; do
    run_command
done