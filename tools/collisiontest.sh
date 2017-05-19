#!/bin/bash

# Idea:
# PROGRAM=$(apg -M CSNL -m 8 -x 16 -n 1 -a 1) # or CsNl to make a symbol optional

PATTERN="[:punct:][:alnum:]"
LEN=$(shuf -i 8-16 -n 1)
ALPHAHASH="$HOME/AlphaHash.exe"

DATA=$(tr -cd "$PATTERN" < /dev/urandom | head -c $LEN)
HASH=$(mono "$ALPHAHASH" "$DATA")

echo "Trying to find hash collisions for: $HASH (original data: $DATA)"

NDATA=$(tr -cd "$PATTERN" < /dev/urandom | head -c $LEN)
RESULT=$(mono "$ALPHAHASH" "$NDATA")
while true; do
    NDATA=$(tr -cd "$PATTERN" < /dev/urandom | head -c $LEN)
    RESULT=$(mono "$ALPHAHASH" "$NDATA")
    echo -n "."
    if [ "$DATA" = "$NDATA" ]; then
        echo "NOTE: same data generated"
    fi

    if [ "$RESULT" = "$HASH" ] && [ "$DATA" != "$NDATA" ]; then
        echo "Collision found!"
        echo "Original hash: $HASH"
        echo "Original data: $DATA"
        echo "Generated hash: $RESULT"
        echo "Generated data: $NDATA"
        exit 1
    fi
done
