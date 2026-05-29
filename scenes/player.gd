extends CharacterBody2D


@export var speed = 100
const PROJECTILE = preload("res://scenes/projectile.tscn")

func _process(delta: float) -> void:
	var move = Input.get_vector("left","right","up","down")
	if move:
		velocity = move *speed
	else:
		velocity = Vector2.ZERO	
		
	move_and_slide()
	
	if Input.is_action_just_pressed("shoot"):
		var new_projectile = PROJECTILE.instantiate()
		new_projectile.global_position = global_position
		add_sibling(new_projectile )
